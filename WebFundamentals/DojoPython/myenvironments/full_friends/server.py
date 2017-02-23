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
mysql = MySQLConnector(app, 'full_friends')
# an example of running a query


# our index route will handle rendering our form
@app.route('/')
def index():
    session['what_page'] = "index"
    if not 'full_list' in session:
        session['full_list'] = []
    if not 'email' in session:
        session['email'] = ""
    if not 'first_name' in session:
        session['first_name'] = ""
    if not 'last_name' in session:
        session['last_name'] = ""
    if not 'returner' in session:
        session['returner'] = False
    if not 'what_page' in session:
        session['what_page'] = ""
    if not 'current_id' in session:
        session['current_id'] = -1
    return render_template("index.html")

@app.route('/friends', methods=['GET'])
def friend_render():
    session['what_page'] = "friend_render"
    return render_template("friends.html")
# this route will handle our form submission
# notice how we defined which HTTP methods are allowed by this route
@app.route('/friends', methods=['POST'])
def create():
   # do some validations here.
   session['what_page'] = "create"
   session['returner'] = False # Use this so you add multiple flash messages at once.
   if len(request.form['email']) < 1:
       flash("You must type in an email address.")
       session['returner'] = True
   elif not EMAIL_REGEX.match(request.form['email']):
       flash("You must type in a valid email address.")
       session['returner'] = True
   if len(request.form['first_name']) < 1:
       flash("You must type in your first name.")
       session['returner'] = True
   elif not str.isalpha(str(request.form['first_name'])):
       flash("Your first name cannot contain numbers or symbols. Sorry, we're biased like that.")
       session['returner'] = True
   if len(request.form['last_name']) < 1:
       flash("You must type in your last name.")
       session['returner'] = True
   elif not str.isalpha(str(request.form['last_name'])): # Done twice in rare case of last name not written but first name written correctly.
       flash("Your last name cannot contain numbers or symbols. Sorry, we're biased like that.")
       session['returner'] = True

   # Set session variables.
   session['email'] = request.form['email']
   session['first_name'] = request.form['first_name']
   session['last_name'] = request.form['last_name']

   # redirect if you passed validation!
   if session['returner'] == False:
       mysql.query_db("INSERT into friends (first_name, last_name, email, created_at) values ('"+session['first_name']+"','"+session['last_name']+"','"+session['email']+"',now())")
       flash(""+session['first_name']+" "+session['last_name']+" is now on your friends list!")
       results = []
       for item in mysql.query_db("SELECT * FROM friends"):
           results.append(item['id'])
           results.append(item['first_name'])
           results.append(item['last_name'])
           results.append(item['email'])
           results.append(item['created_at'])
       session['full_list'] = results
       return redirect('/')

   # If you got this far, you didn't pass validation. Aw.
   return redirect('/friends')


@app.route('/friends/<id>/edit', methods=['GET'])
def edit(id):
   # do some validations here.
   session['what_page'] = "edit"
   session['current_id'] = id
   return render_template("friends.html")


@app.route('/friends/<id>', methods=['POST'])
def update(id):
   # do some validations here.
   session['what_page'] = "update"
   session['returner'] = False # Use this so you add multiple flash messages at once.
   if len(request.form['email']) < 1:
       flash("You must type in an email address.")
       session['returner'] = True
   elif not EMAIL_REGEX.match(request.form['email']):
       flash("You must type in a valid email address.")
       session['returner'] = True
   if len(request.form['first_name']) < 1:
       flash("You must type in your first name.")
       session['returner'] = True
   elif not str.isalpha(str(request.form['first_name'])):
       flash("Your first name cannot contain any numbers, spaces, or symbols. Sorry, we're biased like that.")
       session['returner'] = True
   if len(request.form['last_name']) < 1:
       flash("You must type in your last name.")
       session['returner'] = True
   elif not str.isalpha(str(request.form['last_name'])): # Done twice in rare case of last name not written but first name written correctly.
       flash("Your last name cannot contain any numbers, spaces, or symbols. Sorry, we're biased like that.")
       session['returner'] = True

   # Set session variables.
   session['email'] = request.form['email']
   session['first_name'] = request.form['first_name']
   session['last_name'] = request.form['last_name']

   # redirect if you passed validation!
   if session['returner'] == False:
       # REMEMBER: ID needs to be connected to the database! Should grab ID from database...
       mysql.query_db("UPDATE `full_friends`.`friends` SET `first_name`='"+request.form['first_name']+"', `last_name`='"+request.form['last_name']+"', `email`='"+request.form['email']+"' WHERE `id`='"+id+"'")

    #    mysql.query_db("INSERT into friends (first_name, last_name, email, created_at) values ('"+session['first_name']+"','"+session['last_name']+"','"+session['email']+"',now())")
       flash("Your friend "+request.form['first_name']+" "+request.form['last_name']+" has been updated successfully.")
       results = []
       for item in mysql.query_db("SELECT * FROM friends"):
           results.append(item['id'])
           results.append(item['first_name'])
           results.append(item['last_name'])
           results.append(item['email'])
           results.append(item['created_at'])
       session['full_list'] = results
       return redirect('/')

   # If you got this far, you didn't pass validation. Aw.
   return redirect( '/friends/'+id+'/edit')


@app.route('/friends/<id>/delete', methods=['POST'])
def delete(id):
   # do some validations here.
   session['what_page'] = "delete"
   session['returner'] = True
   # Set session variables.
   flash("You've successfully deleted one of your friends.")
   mysql.query_db("DELETE FROM `full_friends`.`friends` WHERE `id`='"+session['current_id']+"'")
   results = []
   for item in mysql.query_db("SELECT * FROM friends"):
       results.append(item['id'])
       results.append(item['first_name'])
       results.append(item['last_name'])
       results.append(item['email'])
       results.append(item['created_at'])
       session['full_list'] = results

   return redirect("/")


if __name__ == "__main__":
    app.run(debug=True) # run our server
