from django.conf.urls import url
from . import views
# ^ So we can call functions from our routes!
urlpatterns = [
    url(r'^$', views.index),
    url(r'^process_money/(?P<id>\w.*)$', views.process),
    url(r'^reset$', views.reset),
]
