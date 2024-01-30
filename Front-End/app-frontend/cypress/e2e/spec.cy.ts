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
    cy.visit('/my-courses');
  });
});

describe('CourseComponent E2E Tests', () => {
  beforeEach(() => {
    cy.visit('/login');
    cy.get('#username').type('string');
    cy.get('#password').type('string');
    cy.get('#logIn').click();
    cy.visit('/course/8');
  });

  it('should display course details', () => {
    cy.get('.subtitle').should('contain', 'Course description');
  });

  it('should start the course', () => {
    cy.get('.start-course-button').click();
  });
});

describe('CreateCourseComponent E2E Tests', () => {
  cy.visit('/login');
  cy.get('#username').type('string');
  cy.get('#password').type('string');
  cy.get('#logIn').click();
  cy.visit('/course/94');

  it('should save course changes', () => {
    cy.get('.title-input').type('New Course Title');
    cy.get('.description-input').type('New Course Description');
    cy.get('.video-input').type('https://new-video-link.com');
    cy.get('.save').click();
  });
});

describe('CreateCourseComponent E2E Tests', () => {
  beforeEach(() => {
    cy.visit('/login');
    cy.get('#username').type('string');
    cy.get('#password').type('string');
    cy.get('#logIn').click();
    cy.visit('/create-course');
  });

  it('should create a course with valid inputs', () => {
    cy.get('.title-input').type('Valid Course Title');
    cy.get('.description-input').type('Valid Course Description');
    cy.get('.video-input').type('https://valid-video-link.com');
    cy.get('.create-course-button').click();

    cy.url().should('include', '/course/');
    cy.get('.subtitle').should('contain', 'Course description');
  });

  it('should handle incorrect course info', () => {
    // Assuming your component has input fields for title, description, video link, and a button to create the course
    cy.get('.title-input').type('Invalid Course Title'); // Replace with the actual selector and invalid title
    cy.get('.description-input').type('Invalid Course Description'); // Replace with the actual selector and invalid description
    cy.get('.video-input').type('https://invalid-video-link.com'); // Replace with the actual selector and invalid video link
    cy.get('.create').click(); // Replace with the actual selector

    // Assuming your component updates the UI to show an error message
    cy.get('.course-title').should('contain', 'Incorrect course info');
    cy.url().should('not.include', '/course/'); // Ensure the course details page is not navigated to
  });
});

// cypress/integration/my-courses.spec.ts

describe('MyCoursesComponent E2E Tests', () => {
  beforeEach(() => {
    cy.visit('/my-courses');
  });

  it('should display user-specific courses', () => {
    // Assuming your component fetches and displays user-specific courses
    cy.get('.course-item').should('have.length', 2); // Replace with the actual selector and expected number of courses
  });

  it('should navigate to course details', () => {
    // Assuming your component has a button or link to navigate to course details
    cy.get('.course-item:first-child').click(); // Replace with the actual selector for the first course item

    // Assuming your component navigates to the course details page
    cy.url().should('include', '/course/'); // Replace with the expected URL pattern for the course details page
  });

  it('should navigate to create course page', () => {
    // Assuming your component has a button or link to navigate to the create course page
    cy.get('.add-cours').click(); // Replace with the actual selector for the create course button

    // Assuming your component navigates to the create course page
    cy.url().should('include', '/create-course'); // Replace with the expected URL pattern for the create course page
  });
});
