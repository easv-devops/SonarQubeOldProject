const { chromium } = require('@playwright/test');

const { test, expect } = require('@playwright/test');

test.describe('E2E Test Suite', () => {
  let browser;
  let context;
  let page;

  test.beforeAll(async () => {
    browser = await chromium.launch();
    context = await browser.newContext();
    page = await context.newPage();
  });

  test.afterAll(async () => {
    await browser.close();
  });

  test('should visit the log-in page and perform some actions', async () => {
    await page.goto('http://localhost:4200/login');
    await page.fill('#username', 'string');
    await page.fill('#password', 'string');
    await page.click('#logIn');
    await page.waitForTimeout(500);
    await expect(page.locator('.all-courses')).toContainText('All Courses');
  });

  test('should navigate to another page and perform additional tests', async () => {
    await page.goto('http://localhost:4200/login');
    await page.fill('#username', 'string');
    await page.fill('#password', 'string');
    await page.click('#logIn');
    await page.waitForTimeout(500);
    await page.goto('http://localhost:4200/my-courses');
    await expect(page.locator('.my-courses')).toContainText('My courses');
  });
});

test.describe('MyCoursesComponent E2E Tests', () => {
  let browser;
  let context;
  let page;

  test.beforeEach(async () => {
    browser = await chromium.launch();
    context = await browser.newContext();
    page = await context.newPage();
    await page.goto('http://localhost:4200/login');
    await page.fill('#username', 'string');
    await page.fill('#password', 'string');
    await page.click('#logIn');
  });

  test.afterEach(async () => {
    await browser.close();
  });

  test('should display user-specific courses', async () => {
    await page.click('#my-courses');
    await expect(page.locator('.my-courses')).toContainText('My courses');
  });

  test('should navigate to create course page', async () => {
    await page.click('#my-courses');
    await page.click('.add-cours');
    await expect(page.url()).toContain('/create-course');
  });
});

test.describe('CreateCourseComponent E2E Tests', () => {
  let browser;
  let context;
  let page;

  test.beforeAll(async () => {
    browser = await chromium.launch();
    context = await browser.newContext();
    page = await context.newPage();
  });

  test.afterAll(async () => {
    await browser.close();
  });

  test('should create a course with valid inputs', async () => {
    await page.goto('http://localhost:4200/login');
    await page.fill('#username', 'string');
    await page.fill('#password', 'string');
    await page.click('#logIn');
    await page.waitForTimeout(500);
    await page.click('#my-courses');
    await page.click('.add-cours');
    await page.fill('#title', 'ValidCourseTitle');
    await page.fill('#description', 'Valid Course Description new'); // Corrected the typo
    await page.select('select', 'Intermediate');
    await page.fill('#video', 'https://valid-video-link.com');
  });
});
