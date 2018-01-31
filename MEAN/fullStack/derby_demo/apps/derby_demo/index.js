var derby = require('derby');

var app = module.exports = derby.createApp('derby_demo', __filename);


app.use(require('d-bootstrap'));
app.use(require('derby-router'));
app.use(require('derby-debug'));
app.serverUse(module,'derby-jade');
app.serverUse(module, 'derby-stylus');

app.loadViews(__dirname + '/views');
app.loadStyles(__dirname + '/styles');

app.get('home', '/');

