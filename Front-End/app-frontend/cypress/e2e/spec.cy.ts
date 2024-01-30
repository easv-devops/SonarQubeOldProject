describe('Base Test', () => {
  it('Visits the initial project page', () => {
    cy.visit('/')
    cy.contains('app is running!')
  })
})

describe(' E2E Test Suite', () => {
  it('should visit the homepage and perform some actions', () => {
    cy.visit('/login');

    cy.get('#username').type('JohnDoe');
    cy.get('#password').type('secretpassword');
    cy.get('button').click();

    // Assert that the login was successful
    cy.url().should('include', '/home');
    cy.get('.all-courses').should('contain', 'All Courses');
  });

  it('should navigate to another page and perform additional tests', () => {
    // Visit another page
    cy.visit('/my-courses');

  });
});


describe('CourseComponent E2E Tests', () => {
  beforeEach(() => {
    cy.visit('/course/1');
  });

  it('should display course details', () => {
    // Assuming your component displays course details
    cy.get('.course-title').should('contain', 'Course Title'); // Replace with the actual selector and expected title
    cy.get('.course-description').should('contain', 'Course Description'); // Replace with the actual selector and expected description
  });

  it('should start the course', () => {
    // Assuming your component has a button to start the course
    cy.get('.start-course-button').click(); // Replace with the actual selector

    // Assuming your component updates the UI after starting the course
    cy.get('.enrolled-status').should('contain', 'Enrolled');
  });

  it('should save course changes', () => {
    // Assuming your component has input fields for title, description, and video link
    cy.get('.title-input').type('New Course Title'); // Replace with the actual selector and new title
    cy.get('.description-input').type('New Course Description'); // Replace with the actual selector and new description
    cy.get('.video-input').type('https://new-video-link.com'); // Replace with the actual selector and new video link

    // Assuming your component has a button to save changes
    cy.get('.save').click(); // Replace with the actual selector

    // Assuming your component updates the UI after saving changes
    cy.get('.course-title').should('contain', 'New Course Title'); // Replace with the actual selector and expected title
    cy.get('.course-description').should('contain', 'New Course Description'); // Replace with the actual selector and expected description
  });
});

describe('CreateCourseComponent E2E Tests', () => {
  beforeEach(() => {
    cy.visit('/create-course');
  });

  it('should create a course with valid inputs', () => {
    // Assuming your component has input fields for title, description, video link, and a button to create the course
    cy.get('.title-input').type('Valid Course Title'); // Replace with the actual selector and valid title
    cy.get('.description-input').type('Valid Course Description'); // Replace with the actual selector and valid description
    cy.get('.video-input').type('https://valid-video-link.com'); // Replace with the actual selector and valid video link
    cy.get('.create-course-button').click(); // Replace with the actual selector

    // Assuming your component navigates to the course details page after creating the course
    cy.url().should('include', '/course/'); // Replace with the expected URL pattern for the course details page
    cy.get('.course-title').should('contain', 'Valid Course Title'); // Replace with the actual selector and expected title
    cy.get('.course-description').should('contain', 'Valid Course Description'); // Replace with the actual selector and expected description
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

