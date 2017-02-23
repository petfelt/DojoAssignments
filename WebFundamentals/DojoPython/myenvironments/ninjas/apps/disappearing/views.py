from django.shortcuts import render, HttpResponse,redirect

# Create your views here.
def index(request):
    return render(request, "disappearing/index.html")

def ninjas(request, color):
    context = {'myninja' : color}
    return render(request, "disappearing/ninjas.html", context)


def wrong(request):
    return redirect('/')
