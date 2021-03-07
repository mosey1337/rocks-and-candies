module.exports = () => (req, res, next) => {
  next();

  const date = new Date().toLocaleDateString();
  console.log(`[${date}] method: ${req.method} | url: ${req.url} | body: ${JSON.stringify(req.body)}`)
}