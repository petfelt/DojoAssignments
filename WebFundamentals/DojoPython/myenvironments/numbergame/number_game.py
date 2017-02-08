from flask import Flask, render_template, request, redirect, session
import random
app = Flask(__name__)
app.secret_key = 'ThisIsSecret' # you need to set a secret key for security purposes

def set_random_num():
    session['random_num'] = random.randrange(0,101)

def check_nums():
    if int(session['guess']) > int(session['random_num']):
        return 1
    elif int(session['guess']) < int(session['random_num']):
        return -1
    return 0



@app.route('/')
def index():
    set_random_num()
    # Debug code:
    # print "set num: "+str(session['random_num'])
    session['clicked'] = False
    session['checked'] = 500
    return render_template("index.html")


@app.route('/', methods=['POST'])
def set_guess():
   session['clicked'] = True
   session['guess'] = request.form['guess']
   session['checked'] = check_nums()
   # Debug code:
   # print "Random num: "+str(session['random_num'])
   # print "Guess: "+str(session['guess'])
   # print "Check: "+str(session['checked'])
   return render_template('index.html')

app.run(debug=True) # run our server
