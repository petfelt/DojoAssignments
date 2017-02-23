from flask import Flask, render_template, request, redirect, session, flash
# the "re" module will let us perform some regular expression operations
import re
# For password hashing
from flask_bcrypt import Bcrypt
# create a regular expression object that we can use run operations on
EMAIL_REGEX = re.compile(r'^[a-zA-Z0-9.+_-]+@[a-zA-Z0-9._-]+\.[a-zA-Z]+$')
NAME_REGEX = re.compile(r'^[a-zA-Z]')
# import the Connector function
from mysqlconnection import MySQLConnector
app = Flask(__name__)
bcrypt = Bcrypt(app)
app.secret_key = 'KeepItSecretKeepItSafe'
# connect and store the connection in "mysql" note that you pass the database name to the function
mysql = MySQLConnector(app, 'the_wall')
# an example of running a query

# our index route will handle rendering our form
@app.route('/')
def index():
    if not 'returner' in session:
        session['returner'] = False
    if not 'logout' in session:
        session['logout'] = False
    if not 'user' in session:
        session['user'] = [{'first_name':'User'}]
    session['what_page'] = "index"
    return render_template("index.html")

@app.route('/register', methods=['POST'])
def register():
   # do some validations here.
   if not 'user_id' in session:
       session['logout'] = False
   else:
       session['logout'] = True
   session['what_page'] = "register"
   session['returner'] = False # Use this so you add multiple flash messages at once.
   if len(request.form['email']) < 1:
       flash("You must type in an email address.")
       session['returner'] = True
   elif not EMAIL_REGEX.match(request.form['email']):
       flash("You must type in a valid email address.")
       session['returner'] = True
   # Query to make sure email is not taken.
   query = "SELECT * FROM users WHERE email = :email"
   data = {
        'email': request.form['email']
   }
   user = mysql.query_db(query, data)
   if user:
       session['returner'] = True
       flash("This email address is already taken.")

   if len(request.form['first_name']) < 2:
       flash("Your first name is too short.")
       session['returner'] = True
   elif not NAME_REGEX.match(request.form['first_name']):
       flash("Your first name must only contain letters.")
       session['returner'] = True
   if len(request.form['last_name']) < 2:
       flash("Your last name is too short.")
       session['returner'] = True
   elif not NAME_REGEX.match(request.form['last_name']):
       flash("Your last name must only contain letters.")
       session['returner'] = True

   if len(request.form['password']) < 1:
       flash("You have to have a password.")
       session['returner'] = True
   elif len(request.form['password']) < 8:
       flash("Your password must be at least 8 characters long.")
       session['returner'] = True
   elif request.form['password_confirmation'] != request.form['password']:
       flash("Your password and password confirmation must match.")
       session['returner'] = True

   # redirect if you passed validation!
   if session['returner'] == False:
       hashed_pw = bcrypt.generate_password_hash(request.form['password'])

       query = "INSERT into users (first_name, last_name, email, password, created_at, updated_at) VALUES (:first_name, :last_name, :email, :password, NOW(), NOW())"
       data = {
       'first_name': request.form['first_name'],
       'last_name': request.form['last_name'],
       'email': request.form['email'],
       'password': hashed_pw
       }
       user_id = mysql.query_db(query, data)
       session['user_id'] = user_id
       print(session['user_id'])
       session['logout'] = True
       flash(""+request.form['first_name']+" "+request.form['last_name']+", you are now registered! Welcome to The Wall!")
       return redirect('/wall')

   # If you got this far, you didn't pass validation. Aw.
   return redirect('/')

@app.route('/login', methods=["POST"])
def login():
    session['what_page'] = "login"
    query = "SELECT * FROM users WHERE email = :email"
    data = {
         'email': request.form['email']
    }
    user = mysql.query_db(query, data)
    if user:
        # Will return boolean below.
        if bcrypt.check_password_hash(user[0]['password'], request.form['password']):
            session['user_id'] = user[0]['id']
            session['returner'] = False
            session['logout'] = True
            return redirect('/wall')
        else:
            flash("Invalid email/password combination.")
            session['returner'] = True
            return redirect('/')

    # If user not in our values
    else:
        flash("Please enter a valid email, or register to the site.")
        session['returner'] = True
        return redirect('/')

@app.route('/logout')
def logout():
    session.clear()
    return redirect('/')


@app.route('/wall')
def wall():
    session['what_page'] = "wall"
    session['users'] = mysql.query_db("SELECT * FROM users")
    session['posts'] = mysql.query_db("SELECT * FROM posts ORDER BY created_at DESC")
    session['comments'] = mysql.query_db("SELECT * FROM comments")
    # Verify that session is set to prevent malicious users.
    if not 'user_id' in session:
        session['returner'] = True
        flash('Must be logged in to see more.')
        return redirect('/')
    else:
        query = "SELECT * FROM users WHERE id = :id"
        data = {
             'id': session['user_id']
        }
        session['user'] = mysql.query_db(query, data)
    return render_template('wall.html')


@app.route('/post_message', methods=["POST"])
def post_message():
    session['what_page'] = "post_message"
    if(len(request.form['message']) > 1 and len(request.form['title']) > 1):
        query = "INSERT into posts (users_id, created_at, updated_at, title, message) VALUES (:users_id, NOW(), NOW(), :title, :message)"
        data = {
        'users_id': session['user_id'],
        'title': request.form['title'],
        'message': request.form['message']
        }
        post = mysql.query_db(query, data)
        session['returner'] = True
        flash("You just posted a message.")
    elif(len(request.form['message']) < 1):
        flash("You can't post a blank message!")
    else:
        flash("You can't post a message without a title!")

    session['returner'] = False
    return redirect('/wall')

@app.route('/post_comment/<message_id>', methods=["POST"])
def post_comment(message_id):

    session['what_page'] = "post_comment"
    if(len(request.form['comment']) > 1):
        query = "INSERT into comments (users_id, posts_id, created_at, updated_at, comment) VALUES (:users_id, :posts_id, NOW(), NOW(), :comment)"
        data = {
        'users_id': session['user_id'],
        'posts_id': message_id,
        'comment': request.form['comment']
        }
        comment = mysql.query_db(query, data)
        session['returner'] = False
        flash("You just posted a comment.")
    else:
        session['returner'] = True
        flash("You can't post a blank comment!")

    return redirect('/wall')

@app.route('/delete_message/<message_id>', methods=["POST"])
def delete_message(message_id):
    session['what_page'] = "post_comment"
    session['returner'] = True
    # Set session variables.
    mysql.query_db("DELETE FROM `the_wall`.`comments` WHERE `posts_id`='"+message_id+"'")
    mysql.query_db("DELETE FROM `the_wall`.`posts` WHERE `id`='"+message_id+"'")
    flash("You've successfully deleted one of your messages.")
    return redirect('/wall')




if __name__ == "__main__":
    app.run(debug=True) # run our server
