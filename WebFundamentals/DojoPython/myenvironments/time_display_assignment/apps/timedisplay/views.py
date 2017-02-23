from django.shortcuts import render, HttpResponse
from datetime import datetime, timedelta

# Create your views here.
def index(request):
    context = {
    # Need to account for PST timezone.
    "date":(datetime.utcnow() - timedelta(hours=8)).date(),
    "time":(datetime.utcnow() - timedelta(hours=8)).time()
    }
    return render(request, 'timedisplay/index.html', context)

def page(request):
    return render(request, 'timedisplay/page.html')
