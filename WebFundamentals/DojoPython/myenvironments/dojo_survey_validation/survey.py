from flask import Flask, render_template, request, redirect, session, flash
app = Flask(__name__)
app.secret_key = 'KeepItSecretKeepItSafe'


# our index route will handle rendering our form
@app.route('/')
def index():
    if not 'name' in session:
        session['name'] = ""
    if not 'comment' in session:
        session['comment'] = ""
    if not 'location' in session:
        session['location'] = "Seattle"
    if not 'language' in session:
        session['language'] = "Python"
    return render_template("index.html")
# this route will handle our form submission
# notice how we defined which HTTP methods are allowed by this route
@app.route('/result', methods=['POST'])
def process():
   # do some validations here.
   returner = False # Use this so you add multiple flash messages at once.
   if len(request.form['name']) < 1:
       flash("Name cannot be empty!")
       returner = True
   if len(request.form['comment']) < 1:
       flash("Comment section cannot be empty!")
       returner = True
   if len(request.form['comment']) > 120:
       flash("Comment section must be less than 120 characters!")
       returner = True

   # Set session variables.
   session['name'] = request.form['name']
   session['location'] = request.form['location']
   session['language'] = request.form['language']
   session['comment'] = request.form['comment']

   # redirect if you didn't pass validation
   if returner == True:
       return redirect('/')

   # If you got this far, you passed validation! Congrats!
   return render_template('result.html')

@app.route('/result')
def no_user():
    print "Got No Info"
    return render_template('result.html', name='N/A', location='N/A',language='N/A',comment='N/A')


app.run(debug=True) # run our server
