describe(' E2E Test Suite', () => {


  it('should visit the log-in page and perform some actions', () => {
    cy.visit('/');
    cy.get('#username').type('string');
    cy.get('#password').type('string');
    cy.get('#logIn').click();
    cy.wait(500);
    cy.get('.all-courses').should('contain', 'All Courses');

  });



  it('should navigate to another page and perform additional tests', () => {
    cy.visit('/');
    cy.get('#username').type('string');
    cy.get('#password').type('string');
    cy.get('#logIn').click();
    cy.wait(500);
    cy.get('#my-courses').click();
    cy.get('.my-courses').should('contain', 'My courses');

  });
});





describe('MyCoursesComponent E2E Tests', () => {

  beforeEach(() => {
    cy.visit('/');
    cy.get('#username').type('string');
    cy.get('#password').type('string');
    cy.get('#logIn').click();

  });

  it('should display user-specific courses', () => {
    cy.get('#my-courses').click();
    cy.get('.my-courses').should('contain', 'My courses');
  });

  it('should navigate to create course page', () => {
    cy.get('#my-courses').click();
    cy.get('.add-cours').click();
    cy.url().should('include', '/create-course');
  });
});

describe('CreateCourseComponent E2E Tests', () => {

  it('should create a course with valid inputs', () => {
    cy.visit('/');
    cy.get('#username').type('string');
    cy.get('#password').type('string');
    cy.get('#logIn').click();
    cy.wait(500);
    cy.get('#my-courses').click();
    cy.get('.add-cours').click();
    cy.get('#title').type('ValidCourseTitle');
    cy.get('#descriprion').type('Valid Course Description new');
    cy.get('select').select('Intermediate');
    cy.get('#video').type('https://valid-video-link.com');
  });

});
