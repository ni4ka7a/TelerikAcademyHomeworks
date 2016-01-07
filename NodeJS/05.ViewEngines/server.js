'use strict';
var port = 3000;
let express = require('express');
let data = require('./data/data');
let app = express();

app.set('views', __dirname + '/views');
app.set('view engine', 'jade');

app.get('/', function (req, res) {
  res.render('index');
});

app.get('/smartphones', function (req, res) {
  res.render('smartphones', data);
});

app.get('/tablets', function (req, res) {
  res.render('tablets', data);
});

app.get('/wearables', function (req, res) {
  res.render('wearables', data);
});

app.listen(port, function () {
  console.log('Server is runnig on port: ' + port);
});
