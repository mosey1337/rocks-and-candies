const express = require('express');
const logger = require('./logger');
const routes = require('./routes');
const app = express();

app.use(express.json());
app.use(logger())

app.get('/api/users', routes.users);

app.get('/api/users/new', routes.create)

app.post('/api/users/score', routes.score)

app.post('/api/users/name', routes.name)

app.get('/api/leaderboard', routes.leaderboard);

app.listen(8080);