describe(' E2E Test Suite', () => {
  it('should visit the homepage and perform some actions', () => {
    cy.visit('/login');

    cy.get('#username').type('string');
    cy.get('#password').type('string');
    cy.get('#logIn').click();

    cy.url().should('include', '/home');
    cy.get('.all-courses').should('contain', 'All Courses');
  });

  it('should navigate to another page and perform additional tests', () => {
    cy.visit('/login');
    cy.get('#username').type('string');
    cy.get('#password').type('string');
    cy.get('#logIn').click();
    cy.visit('/my-courses');
  });
});

describe('CourseComponent E2E Tests', () => {
  beforeEach(() => {
    cy.visit('/login');
    cy.get('#username').type('string');
    cy.get('#password').type('string');
    cy.get('#logIn').click();
    cy.wait(500);
    cy.visit('/course/80');
  });

  it('should display course details', () => {
    cy.get('.subtitle').should('contain', 'Course description');
  });

  it('should start the course', () => {
    cy.get('.start-course-button').click();
  });

});



describe('CreateCourseComponent E2E Tests', () => {
  beforeEach(() => {
    cy.visit('/login');
    cy.get('#username').type('string');
    cy.get('#password').type('string');
    cy.get('#logIn').click();
    cy.wait(500);
    cy.visit('/create-course');
  });

  it('should create a course with valid inputs', () => {
    cy.get('#title').type('ValidCourseTitle');
    cy.get('#descriprion').type('Valid Course Description new');
    cy.get('select').select('Intermediate');
    cy.get('#video').type('https://valid-video-link.com');
    cy.get('.create').click();
  });

});


describe('MyCoursesComponent E2E Tests', () => {
  beforeEach(() => {
    cy.visit('/login');
    cy.get('#username').type('string');
    cy.get('#password').type('string');
    cy.get('#logIn').click();
    cy.wait(500);
    cy.visit('/my-courses');
  });

  it('should display user-specific courses', () => {
    cy.get('.my-courses').should('contain', 'My courses');
  });

  it('should navigate to course details', () => {
    cy.get('.course:first-child').click();
    cy.url().should('include', '/course/94');
  });

  it('should navigate to create course page', () => {
    cy.get('.add-cours').click();

    cy.url().should('include', '/create-course');
  });
});
