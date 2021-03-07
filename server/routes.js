const storage = require('./storage');
const User = require('./models/user');


module.exports.leaderboard = (req, res) => {
  const leaderboard = storage.users
    .filter(u => u.score > 0)
    .sort((a, b) => a.score < b.score 
      ? 1 
      : -1)

  res.json(leaderboard)
}

module.exports.score = (req, res) => {
  const { id, score } = req.body;

  const user = storage.users.filter(u => u.id == id)[0];

  if (user.score < score) {
    user.update({ score })
  }

  res.json(user)
}

module.exports.users = (req, res) => res.json(storage.users);

module.exports.create = (req, res) => {
  const nextId = storage.nextId();

  const user = new User(nextId, `Player ${nextId}`, 0);

  storage.users.push(user);

  console.dir(user);

  res.json(user);
}

module.exports.name = (req, res) => {
  const { id, name } = req.body;
  
  const user = storage.users.filter(u => u.id === id)[0];
  
  user.update({ name })

  res.json(user)
}