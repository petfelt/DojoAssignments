from django.shortcuts import render, redirect

# Create your views here.
def index(request):
    if not 'your_name' in request.session:
        request.session['your_name'] = ''
    if not 'location' in request.session:
        request.session['location'] = 'Seattle'
    if not 'language' in request.session:
        request.session['language'] = 'Python'
    if not 'comment' in request.session:
        request.session['comment'] = ''
    if not 'number' in request.session:
        request.session['number'] = 0
    return render(request, 'survey/index.html')

def process(request):
    if request.method == "POST":
        request.session['your_name'] = request.POST['your_name']
        request.session['location'] = request.POST['location']
        request.session['language'] = request.POST['language']
        request.session['comment'] = request.POST['comment']
        request.session['number'] += 1
        return redirect('/result')
    else:
        return redirect('/')

def result(request):
    if not 'number' in request.session:
        request.session['number'] = 0
    return render(request, 'survey/result.html')

def wrong(request):
    return redirect('/')
