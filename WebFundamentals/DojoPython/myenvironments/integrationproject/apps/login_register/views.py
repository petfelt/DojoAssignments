from django.shortcuts import render, HttpResponse, redirect
from django.contrib import messages
from django.core.exceptions import ObjectDoesNotExist
import re, bcrypt

# create a regular expression object that we can use run operations on
EMAIL_REGEX = re.compile(r'^[a-zA-Z0-9.+_-]+@[a-zA-Z0-9._-]+\.[a-zA-Z]+$')
NAME_REGEX = re.compile(r'^[a-zA-Z]')

from .models import User

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
    return render(request, "login_register/index.html", {"usrs":usrs})

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
            pw = request.POST['password']
            pw = pw.encode()
            hashed_pw = bcrypt.hashpw(pw, bcrypt.gensalt())

            user_id = User.objects.create(first_name=request.POST['first_name'],last_name=request.POST['last_name'], email=request.POST['email'],password=hashed_pw)

            request.session['user_id'] = user_id.id
            print(request.session['user_id'])

            request.session['logout'] = True
            messages.info(request, ""+request.POST['first_name']+" "+request.POST['last_name']+", you are now registered! Welcome to this website!")
            return redirect('/success')

    # If you got this far, you didn't pass validation. Aw.
    return redirect('/')

def login(request):
    if request.method == "POST":
        request.session['what_page'] = "login"
        try:
            user = User.objects.get(email=request.POST['email'])
        except ObjectDoesNotExist:
            messages.info(request, "Please enter a valid email or register to this website.")
            request.session['returner'] = True
            return redirect('/')
        if bcrypt.checkpw((request.POST['password']).encode(), user.password.encode()):
            request.session['user_id'] = user.id
            request.session['returner'] = False
            request.session['logout'] = True
            return redirect('/success')
        else:
            messages.info(request, "Invalid email/password combination.")
            request.session['returner'] = True

    # If user not in our values
    return redirect('/')

def logout(request):
    request.session.clear()
    return redirect('/')

def success(request):
    usrs = User.objects.all() # In case user is logged in on first page, make their name reference-able.
    return render(request, "login_register/success.html", {"usrs":usrs})
