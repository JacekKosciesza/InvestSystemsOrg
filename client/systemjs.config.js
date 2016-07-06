/**
 * System configuration for Angular 2 samples
 * Adjust as necessary for your application needs.
 */
(function (global) {
    // map tells the System loader where to look for things
    var map = {
        'app': 'app', // 'dist',
        '@angular': 'node_modules/@angular',
        'angular2-in-memory-web-api': 'node_modules/angular2-in-memory-web-api',
        'rxjs': 'node_modules/rxjs',
        '@ngrx': 'node_modules/@ngrx',
        '@angular2-material': 'node_modules/@angular2-material',
        'firebase': 'node_modules/firebase/firebase.js',
        'angularfire2': 'node_modules/angularfire2'
    };
    // packages tells the System loader how to load when no filename and/or no extension
    var packages = {
        'app': { main: 'main.js', defaultExtension: 'js' },
        'rxjs': { defaultExtension: 'js' },
        'angular2-in-memory-web-api': { main: 'index.js', defaultExtension: 'js' },
        '@ngrx/core': { main: 'index.js', format: 'cjs' },
        '@ngrx/store': { main: 'index.js', format: 'cjs' },
        '@angular2-material/core': { format: 'cjs', defaultExtension: 'js', main: 'core.js' },
        '@angular2-material/toolbar': { format: 'cjs', defaultExtension: 'js', main: 'toolbar.js' },
        '@angular2-material/icon': { format: 'cjs', defaultExtension: 'js', main: 'icon.js' },
        '@angular2-material/sidenav': { format: 'cjs', defaultExtension: 'js', main: 'sidenav.js' },
        '@angular2-material/button': { format: 'cjs', defaultExtension: 'js', main: 'button.js' },
        '@angular2-material/card': { format: 'cjs', defaultExtension: 'js', main: 'card.js' },
        '@angular2-material/grid-list': { format: 'cjs', defaultExtension: 'js', main: 'grid-list.js' },
        'angularfire2': { defaultExtension: 'js', main: 'angularfire2.js' }
    };
    var ngPackageNames = [
        'common',
        'compiler',
        'core',
        'http',
        'platform-browser',
        'platform-browser-dynamic',
        'router',
        'upgrade',
    ];
    // Individual files (~300 requests):
    function packIndex(pkgName) {
        packages['@angular/' + pkgName] = { main: 'index.js', defaultExtension: 'js' };
    }
    // Bundled (~40 requests):
    function packUmd(pkgName) {
        packages['@angular/' + pkgName] = { main: '/bundles/' + pkgName + '.umd.js', defaultExtension: 'js' };
    }
    // Most environments should use UMD; some (Karma) need the individual index files
    var setPackageConfig = System.packageWithIndex ? packIndex : packUmd;
    // Add package entries for angular packages
    ngPackageNames.forEach(setPackageConfig);
    var config = {
        map: map,
        packages: packages
    };
    System.config(config);
})(this);
