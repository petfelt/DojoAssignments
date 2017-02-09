from flask import Flask, render_template, request, redirect, session
import random
app = Flask(__name__)
app.secret_key = 'ThisIsSecret' # you need to set a secret key for security purposes


    # session['activity_text'] = session['activity_text'] +"\n"+session['current_activity']






@app.route('/')
def index():
    if not 'gold' in session:
        session['gold'] = 0
    if not 'activities' in session:
        session['activities'] = []
    return render_template("index.html")


@app.route('/process_money/<id>', methods=['POST'])
def set_guess(id):
    buildings = {
    'farm': random.randrange(10,20),
    'cave': random.randrange(5,10),
    'house': random.randrange(2,5),
    'casino': random.randrange(-50,50)
    }
    # {% if {{session['oldgold']}} < {{session['gold']}} %} "green" {% else %} "red" {% endif %}
    if request.form['building'] in buildings:
        # Append color name to read during Flask templates:
        session['activities'].append("{}".format('green'if buildings[id] >0 else 'red'))

        # Then write string to add.
        activity = "{} {} golds at the {}!".format('Earned'if buildings[id] >0 else 'Lost',abs(int(buildings[id])), id)
        # Append that string.
        session['activities'].append(activity)
        session['gold'] += buildings[id]
    return redirect('/')


@app.route('/reset', methods=['POST'])
def reset():
    session.clear()
    session['gold'] = 0
    session['activities'] = []
    return redirect('/')

if __name__ == "__main__":
    app.run(debug=True) # run our server
