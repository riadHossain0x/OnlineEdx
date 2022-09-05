﻿using OnlineEdx.Infrastructure.UnitOfWorks;
using OnlineEdx.Infrastructure.Entities.Membership;
using OnlineEdx.Infrastructure.Entities;
using CourseBO = OnlineEdx.Infrastructure.BusinessObjects.Course;
using AutoMapper;

namespace OnlineEdx.Infrastructure.Services
{
    public class EnrollmentService : IEnrollmentService
    {
        private readonly IEdxUnitOfWork _edxUnitOfWork;
        private readonly ICourseService _courseService;
        private readonly IMapper _mapper;

        public EnrollmentService(IEdxUnitOfWork edxUnitOfWork, ICourseService courseService, IMapper mapper)
        {
            _edxUnitOfWork = edxUnitOfWork;
            _courseService = courseService;
            _mapper = mapper;
        }

        public void EnrollCourseAsync(Guid courseId, ApplicationUser user)
        {
            var count = _edxUnitOfWork.EnrollmentRepository.Find(x => x.Course.Id == courseId 
            && x.ApplicationUser.Id == user.Id).Count();

            if (count > 0)
                throw new InvalidOperationException("You already enrolled this course");

            var course = _mapper.Map<Course>(_courseService.GetById(courseId));

            var enrollEntity = new Enroll();
            enrollEntity.Course = course;
            enrollEntity.ApplicationUser = user;

            _edxUnitOfWork.EnrollmentRepository.Merge(enrollEntity);
            _edxUnitOfWork.SaveChanges();
        }

        public IList<CourseBO> GetEnrolledCourses(Guid userId)
        {
            var courseEO = _edxUnitOfWork.EnrollmentRepository.Find(x => x.ApplicationUser.Id == userId).Select(x => new Course
            {
                Id = x.Course.Id,
                Title = x.Course.Title,
                Description = x.Course.Description,
                Image = x.Course.Image
            });
            var courseBO = _mapper.Map<IList<CourseBO>>(courseEO);

            return courseBO;
        }
    }
}
