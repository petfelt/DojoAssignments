from django.shortcuts import render, HttpResponse, redirect
from django.contrib import messages
from django.core.exceptions import ObjectDoesNotExist
import re, crypt

# create a regular expression object that we can use run operations on
EMAIL_REGEX = re.compile(r'^[a-zA-Z0-9.+_-]+@[a-zA-Z0-9._-]+\.[a-zA-Z]+$')
NAME_REGEX = re.compile(r'^[a-zA-Z]')

from .models import User, Message, Comment

# Create your views here.
def index(request):
    if not 'returner' in request.session:
        request.session['returner'] = False
    if not 'logout' in request.session:
        request.session['logout'] = False
    if not 'user' in request.session:
        request.session['user'] = [{'first_name':'User'}]
    usrs = User.objects.all() # In case user is logged in on first page, make their name reference-able.
    request.session['what_page'] = "index"
    return render(request, "thewall/index.html", {"usrs":usrs})

def register(request):
    if request.method == "POST":
        # do some validations here.
        if not 'user_id' in request.session:
            request.session['logout'] = False
            request.session['returner'] = False
        else:
            request.session['logout'] = True
            request.session['what_page'] = "register"
            request.session['returner'] = False # Use this so you add multiple "flash" messages at once.
        if len(request.POST['email']) < 1:
            messages.info(request, "You must type in an email address.")
            request.session['returner'] = True
        elif not EMAIL_REGEX.match(request.POST['email']):
            messages.info(request, "You must type in a valid email address.")
            request.session['returner'] = True
        # Query to make sure email is not taken.
        user = User.objects.filter(email=request.POST['email'])
        if user:
            request.session['returner'] = True
            messages.info(request, "This email address is already taken.")

        if len(request.POST['first_name']) < 2:
            messages.info(request, "Your first name is too short.")
            request.session['returner'] = True
        elif not NAME_REGEX.match(request.POST['first_name']):
            messages.info(request, "Your first name must only contain letters.")
            request.session['returner'] = True
        if len(request.POST['last_name']) < 2:
            messages.info(request, "Your last name is too short.")
            request.session['returner'] = True
        elif not NAME_REGEX.match(request.POST['last_name']):
            messages.info(request, "Your last name must only contain letters.")
            request.session['returner'] = True

        if len(request.POST['password']) < 1:
            messages.info(request, "You have to have a password.")
            request.session['returner'] = True
        elif len(request.POST['password']) < 8:
            messages.info(request, "Your password must be at least 8 characters long.")
            request.session['returner'] = True
        elif request.POST['password_confirmation'] != request.POST['password']:
            messages.info(request, "Your password and password confirmation must match.")
            request.session['returner'] = True

            # redirect if you passed validation!
        if request.session['returner'] == False:
            nothashed_pw = request.POST['password']

            user_id = User.objects.create(first_name=request.POST['first_name'],last_name=request.POST['last_name'], email=request.POST['email'],password=nothashed_pw)

            request.session['user_id'] = user_id.id
            print(request.session['user_id'])

            request.session['logout'] = True
            messages.info(request, ""+request.POST['first_name']+" "+request.POST['last_name']+", you are now registered! Welcome to The Wall!")
            return redirect('/wall')

    # If you got this far, you didn't pass validation. Aw.
    return redirect('/')

def login(request):
    if request.method == "POST":
        request.session['what_page'] = "login"
        try:
            user = User.objects.get(email=request.POST['email'])
        except ObjectDoesNotExist:
            messages.info(request, "Please enter a valid email or register to The Wall.")
            request.session['returner'] = True
            return redirect('/')
        if user.password == request.POST['password']:
            request.session['user_id'] = user.id
            request.session['returner'] = False
            request.session['logout'] = True
            return redirect('/wall')
        else:
            messages.info(request, "Invalid email/password combination.")
            request.session['returner'] = True

    # If user not in our values
    return redirect('/')

def logout(request):
    request.session.clear()
    return redirect('/')


def wall(request):
    request.session['what_page'] = "wall"
    msgs = Message.objects.all().order_by('-created_at')
    cmts = Comment.objects.all()
    usrs = User.objects.all()

    # Verify that request.session is set to prevent malicious users.
    if not 'user_id' in request.session:
        request.session['returner'] = True
        messages.info(request, 'Must be logged in to see more.')
        return redirect('/')
    else:
        user = User.objects.get(id=request.session['user_id'])

        request.session['user'] = user.id
    return render(request, 'thewall/wall.html', {'msgs':msgs, 'cmts':cmts, 'usrs':usrs})


def post_message(request):
    if request.method == "POST":
        request.session['what_page'] = "post_message"
        if(len(request.POST['message']) > 1):
            post = Message.objects.create(message=request.POST['message'], user=User.objects.get(id=request.session['user_id']))

            request.session['returner'] = True
            messages.info(request, "You just posted a message.")
        else:
            messages.info(request, "You can't post a blank message!")

        request.session['returner'] = False
    return redirect('/wall')

def post_comment(request, message_id):
    if request.method == "POST":
        request.session['what_page'] = "post_comment"
        if(len(request.POST['comment']) > 1):
            comment = Comment.objects.create(comment=request.POST['comment'], user=User.objects.get(id=request.session['user_id']), message=Message.objects.get(id=message_id))
            request.session['returner'] = False
            messages.info(request, "You just posted a comment.")
        else:
            request.session['returner'] = True
            messages.info(request, "You can't post a blank comment!")

    return redirect('/wall')

def delete_message(request, message_id):
    if request.method == "POST":
        request.session['what_page'] = "delete_message"
        request.session['returner'] = True
        # delete it.
        Message.objects.filter(id=message_id).delete()
        messages.info(request, "You've successfully deleted one of your messages.")
    return redirect('/wall')
