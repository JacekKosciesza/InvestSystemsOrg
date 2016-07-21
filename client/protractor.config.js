exports.config = {
    framework: 'jasmine',
    seleniumAddress: 'http://localhost:4444/wd/hub',
    specs: ['app/**/**.e2e-spec.ts', 'app/**/*.e2e-spec.ts'],
    //specs: ['tasks-list.spec.js'],
    capabilities: {
        browserName: 'chrome'
    },
    multiCapabilities: [
        // TODO: turn off browserSync
        { browserName: 'chrome' },
        //{ browserName: 'firefox' }
        //{ browserName: 'internet explorer' }
    ],
    jasmineNodeOpts: {
        showColors: true
    }
};