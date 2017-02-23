from django.conf.urls import url
from . import views

urlpatterns = [
    url(r'^$', views.index),
    url(r'^register/$', views.register),
    url(r'^login/$', views.login),
    url(r'^logout/$', views.logout),
    url(r'^wall/$', views.wall),
    url(r'^post_message/$', views.post_message),
    url(r'^post_comment/(?P<message_id>\d.*)$', views.post_comment),
    url(r'^delete_message/(?P<message_id>\d.*)$', views.delete_message),


]
