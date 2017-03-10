from django.shortcuts import render, HttpResponse, redirect
from django.contrib import messages
from django.core.exceptions import ObjectDoesNotExist
from django.core.urlresolvers import reverse

from .models import Course, User

# Create your views here.
def index(request):
    context = {
        'curses': Course.objects.all(),
        'users': User.objects.all(),

    }
    return render(request, "courses/index.html", context)

def create(request):
    if request.method == 'POST':
        modelResponse = Course.objects.add_course(request.POST)
        if not modelResponse['status']:
            for error in modelResponse['errors']:
                messages.error(request, error)
        else:
            messages.info(request, "A new course was successfully added.")

    return redirect(reverse('courses:index'))

def destroy(request, course_id):
    context = {
        'course': Course.objects.get(id=course_id),
    }
    return render (request, "courses/destroy.html", context)

def delete_course(request, course_id):
    if request.method == "POST":
        # delete it.
        modelResponse = Course.objects.remove_course(course_id)
        if modelResponse:
            messages.error(request, modelResponse['info'])
    return redirect(reverse('courses:index'))

def add_user(request):
    this_course = Course.objects.get(id=request.POST['course'])
    this_user = User.objects.get(id=request.POST['user'])
    this_course.all_users.add(this_user)
    request.session['returner'] = False
    messages.info(request, "You've added a user to a course.")
    return redirect('/courses')
