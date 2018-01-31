var shareDbMongo = require('sharedb-mongo');
var coffeeify = require('coffeeify');

module.exports = store;

function store(derby, publicDir) {
  var db = shareDbMongo(process.env.MONGO_URL + '?auto_reconnect=true', {safe: true});

  derby.use(require('racer-bundle'));


  var store = derby.createBackend({db: db});

  store.on('bundle', function(browserify) {

    browserify.transform({global: true}, coffeeify);

    var pack = browserify.pack;
    browserify.pack = function(opts) {
      var detectTransform = opts.globalTransform.shift();
      opts.globalTransform.push(detectTransform);
      return pack.apply(this, arguments);
    };
  });

  return store;
}
