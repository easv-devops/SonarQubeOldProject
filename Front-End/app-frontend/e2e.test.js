const { describe, it, before, after } = require('@playwright/test');

describe('E2E Test Suite', () => {
  let browser;
  let context;
  let page;

  beforeAll(async () => {
    browser = await chromium.launch();
    context = await browser.newContext();
    page = await context.newPage();
  });

  afterAll(async () => {
    await browser.close();
  });

  it('should visit the log-in page and perform some actions', async () => {
    await page.goto('http://localhost/4200/login');
    await page.fill('#username', 'string');
    await page.fill('#password', 'string');
    await page.click('#logIn');
    await page.waitForTimeout(500);
    await expect(page.locator('.all-courses')).toContainText('All Courses');
  });

  it('should navigate to another page and perform additional tests', async () => {
    await page.goto('http://localhost/4200/login');
    await page.fill('#username', 'string');
    await page.fill('#password', 'string');
    await page.click('#logIn');
    await page.waitForTimeout(500);
    await page.goto('http://your-app-url/my-courses');
    await expect(page.locator('.my-courses')).toContainText('My courses');
  });
});

describe('MyCoursesComponent E2E Tests', () => {
  let browser;
  let context;
  let page;

  beforeEach(async () => {
    browser = await chromium.launch();
    context = await browser.newContext();
    page = await context.newPage();
    await page.goto('http://localhost/4200/login');
    await page.fill('#username', 'string');
    await page.fill('#password', 'string');
    await page.click('#logIn');
  });

  afterEach(async () => {
    await browser.close();
  });

  it('should display user-specific courses', async () => {
    await page.click('#my-courses');
    await expect(page.locator('.my-courses')).toContainText('My courses');
  });

  it('should navigate to create course page', async () => {
    await page.click('#my-courses');
    await page.click('.add-cours');
    await expect(page.url()).toContain('/create-course');
  });
});

describe('CreateCourseComponent E2E Tests', () => {
  let browser;
  let context;
  let page;

  beforeAll(async () => {
    browser = await chromium.launch();
    context = await browser.newContext();
    page = await context.newPage();
  });

  afterAll(async () => {
    await browser.close();
  });

  it('should create a course with valid inputs', async () => {
    await page.goto('http://localhost:4200/login');
    await page.fill('#username', 'string');
    await page.fill('#password', 'string');
    await page.click('#logIn');
    await page.waitForTimeout(500);
    await page.click('#my-courses');
    await page.click('.add-cours');
    await page.fill('#title', 'ValidCourseTitle');
    await page.fill('#descriprion', 'Valid Course Description new');
    await page.select('select', 'Intermediate');
    await page.fill('#video', 'https://valid-video-link.com');
  });
});
