const users = []

const next = () => {
  let nextId = 1;

  return function() {
    return nextId++;
  }
}

module.exports = {
  users,
  nextId: next(),
};