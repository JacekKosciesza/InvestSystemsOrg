importScripts('/service-worker-cache-polyfill.js');

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
        caches.match(event.request)
        .then(response => response || fetch(event.request))
        .catch(() => {
            if (event.request.mode == 'navigate') {
                return caches.match('/offline.html');
            }
        })
    );
});

// TODO: background sync
self.addEventListener('sync', event => {
   if (event.tag == 'todo') {
   };
});