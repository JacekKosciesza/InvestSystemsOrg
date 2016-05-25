importScripts('/serviceworker-cache-polyfill.js');

self.addEventListener('install', e => {
    e.waitUntil(
        caches.open('investsystems').then(cache => {
            return cache.addAll([
                '/',
                '/index.html',
                '/index.html?homescreen=1',
            ])
                .then(() => self.skipWaiting());
        })
    )
});

self.addEventListener('activate', event => {
    event.waitUntil(self.clients.claim());
});

self.addEventListener('fetch', event => {
    console.log(event.request.url);
    event.respondWith(
        caches.match(event.request).then(response => {
            return response || fetch(event.request);
        })
    );
});