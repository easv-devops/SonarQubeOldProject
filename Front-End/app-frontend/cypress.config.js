const { defineConfig } = require('cypress')

module.exports = defineConfig({

  e2e: {
    //'baseUrl': 'https://daeducation-99d82.web.app/'
    'baseUrl': 'http://localhost:4200/'

  },


  component: {
    devServer: {
      framework: 'angular',
      bundler: 'webpack',
    },
    specPattern: '**/*.cy.ts'
  }

})
