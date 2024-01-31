const { defineConfig } = require('cypress')

module.exports = defineConfig({

  e2e: {
    'baseUrl': 'http://127.0.0.1:4200'
  },


  component: {
    devServer: {
      framework: 'angular',
      bundler: 'webpack',
    },
    specPattern: '**/*.cy.ts'
  }

})
