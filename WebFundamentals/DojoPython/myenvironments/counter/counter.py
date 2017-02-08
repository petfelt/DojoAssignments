from flask import Flask, render_template, request, redirect, session
app = Flask(__name__)
app.secret_key = 'ThisIsSecret' # you need to set a secret key for security purposes

def session_counter_increase():
  try:
    session['counter'] += 1
  except KeyError:
    session['counter'] = 1

def reset():
    try:
      session['counter'] = -1
    except KeyError:
      session['counter'] = -1


@app.route('/')
def index():
    session_counter_increase()
    return render_template("index.html")

@app.route('/', methods=['POST','OTHER'])
def index2():
    if request.method == 'POST':
        session_counter_increase()
    else:
        reset()
    return render_template("index.html")

app.run(debug=True) # run our server
