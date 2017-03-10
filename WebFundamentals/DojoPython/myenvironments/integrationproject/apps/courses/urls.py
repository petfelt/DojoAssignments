from django.conf.urls import url
from . import views

urlpatterns = [
    url(r'^$', views.index, name = 'index'),
    url(r'^create/$', views.create, name = 'create'),
    url(r'^courses/destroy/(?P<course_id>\d.*)/$', views.destroy, name = 'destroy'),
    url(r'^courses/delete/(?P<course_id>\d.*)$', views.delete_course, name = 'delete'),
    url(r'^courses/add_user$', views.add_user, name = 'add_user'),

]
