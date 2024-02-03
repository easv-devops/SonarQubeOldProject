const { defineConfig } = require('cypress')

module.exports = defineConfig({

  e2e: {
    'baseUrl': 'https://daeducation-99d82.web.app/'
  },


  component: {
    devServer: {
      framework: 'angular',
      bundler: 'webpack',
    },
    specPattern: '**/*.cy.ts'
  }

})
