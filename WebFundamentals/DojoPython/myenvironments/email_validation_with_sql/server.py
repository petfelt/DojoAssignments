from flask import Flask, render_template, request, redirect, session, flash
# the "re" module will let us perform some regular expression operations
import re
# create a regular expression object that we can use run operations on
EMAIL_REGEX = re.compile(r'^[a-zA-Z0-9.+_-]+@[a-zA-Z0-9._-]+\.[a-zA-Z]+$')
# import the Connector function
from mysqlconnection import MySQLConnector
app = Flask(__name__)
app.secret_key = 'KeepItSecretKeepItSafe'
# connect and store the connection in "mysql" note that you pass the database name to the function
mysql = MySQLConnector(app, 'email_validation')
# an example of running a query
print mysql.query_db("SELECT * FROM emails")


# our index route will handle rendering our form
@app.route('/')
def index():
    if not 'email' in session:
        session['email'] = ""
    if not 'returner' in session:
        session['returner'] = False
    if not 'email_list' in session:
        session['email_list'] = ""
    return render_template("index.html")
# this route will handle our form submission
# notice how we defined which HTTP methods are allowed by this route
@app.route('/success', methods=['POST'])
def process():
   # do some validations here.
   session['returner'] = False # Use this so you add multiple flash messages at once.
   if len(request.form['email']) < 1:
       flash("You must type in an email address.")
       session['returner'] = True
   elif not EMAIL_REGEX.match(request.form['email']):
       flash("You must type in a valid email address.")
       session['returner'] = True

   # Set session variables.
   session['email'] = request.form['email']

   # redirect if you passed validation!
   if session['returner'] == False:
       mysql.query_db("INSERT into emails (email, created_at) values ('"+session['email']+"',now())")
       flash("The email address you entered, ("+session['email']+"), is a VALID email address. Thank you!")
       results = []
       for item in mysql.query_db("SELECT * FROM emails"):
           results.append(item['email'])
           results.append(item['created_at'])
       session['email_list'] = results
       return redirect('/success')

   # If you got this far, you didn't pass validation. Aw.
   return redirect('/')


@app.route('/success')
def success():

    return render_template("success.html")



if __name__ == "__main__":
    app.run(debug=True) # run our server
