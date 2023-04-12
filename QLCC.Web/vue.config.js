const { defineConfig } = require('@vue/cli-service')
const publicPath = process.env.NODE_ENV === 'production' ? '/' : '/'
module.exports = defineConfig({
  transpileDependencies: true,
  assetsDir: '',
  publicPath: publicPath
})
