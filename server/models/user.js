function User(id, name, score) {
  this.id = id;
  this.name = name;
  this.score = score;
}

User.prototype.update = function(user) {
  if (user.score && user.score > this.score) {
    this.score = user.score;
  }

  if (user.name && user.name !== this.name) {
    this.name = user.name;
  }
}

module.exports = User;