from __future__ import unicode_literals

from django.db import models
from ..login_register.models import User

# Create your models here.
class CourseManager(models.Manager):
    def add_course(self, postData):
        errors = []
        use_for_related_fields = True

        if not postData['course_name']:
            errors.append('A course name is required.')
        if not postData['description']:
            errors.append('A course description is required.')

        if errors:
            return {'status': False, 'errors': errors}
        else:
            self.create(name=postData['course_name'],description=postData['description'])
            return {'status': True}

    def remove_course(self,course_id):
        info = "You've successfully deleted one of the courses."
        self.filter(id=course_id).delete()
        return {'status': False, 'info': info}

    def counter(self,course_id):
        return self.filter(id=course_id).all_users.count()
        # may not need this.


class Course(models.Model):
    name = models.CharField(max_length = 255)
    description = models.CharField(max_length = 1000)
    all_users = models.ManyToManyField(User, related_name="all_courses")
    created_at = models.DateTimeField(auto_now_add = True)
    updated_at = models.DateTimeField(auto_now = True)

    objects = CourseManager()
