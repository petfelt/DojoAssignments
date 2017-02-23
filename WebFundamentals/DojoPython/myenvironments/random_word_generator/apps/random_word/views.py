from django.shortcuts import render, HttpResponse, redirect
import random
import string
# Create your views here.
def index(request):
    if not 'ran_word' in request.session:
        request.session['ran_word'] = ''.join(random.choice(string.ascii_uppercase + string.digits) for _ in range(14))
    if not 'number' in request.session:
        request.session['number'] = 0

    return render(request, 'random_word/index.html')

def button(request):
    if request.method == "POST":
        request.session['number'] += 1
        request.session['ran_word'] = ''.join(random.choice(string.ascii_uppercase + string.digits) for _ in range(14))
    return redirect('/')
