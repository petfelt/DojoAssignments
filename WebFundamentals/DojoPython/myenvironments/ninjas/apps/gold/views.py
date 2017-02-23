from django.shortcuts import render, HttpResponse,redirect
import random

# Create your views here.
def index(request):
    if not 'gold' in request.session:
        request.session['gold'] = 0
    if not 'activities' in request.session:
        request.session['activities'] = []
    return render(request, "gold/index.html")

def process(request, id):
    if request.method == "POST":
        buildings = {
        'farm': random.randrange(10,20),
        'cave': random.randrange(5,10),
        'house': random.randrange(2,5),
        'casino': random.randrange(-50,50)
        }
        # {% if {{session['oldgold']}} < {{session['gold']}} %} "green" {% else %} "red" {% endif %}
        if id in buildings:
            # Append color name to read during Flask templates:
            request.session['activities'].append("{}".format('green'if buildings[id] >0 else 'red'))

            # Then write string to add.
            activity = "{} {} golds at the {}!".format('Earned'if buildings[id] >0 else 'Lost',abs(int(buildings[id])), id)
            # Append that string.
            request.session['activities'].append(activity)
            request.session['gold'] += buildings[id]
    return redirect('/')

def reset(request):
    request.session.clear()
    request.session['gold'] = 0
    request.session['activities'] = []
    return redirect('/')



def wrong(request):
    return redirect('/')
