const { defineConfig } = require('cypress')

module.exports = defineConfig({

  e2e: {
    'baseUrl': 'https://da-education.onrender.com/'
    //'baseUrl': 'http://localhost:4200/'

  },


  component: {
    devServer: {
      framework: 'angular',
      bundler: 'webpack',
    },
    specPattern: '**/*.cy.ts'
  }

})
