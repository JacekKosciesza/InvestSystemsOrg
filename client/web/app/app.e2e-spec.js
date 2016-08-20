describe('App', function () {
    beforeEach(function () {
        browser.get('/');
    });
    it('should have a title', function () {
        var subject = browser.getTitle();
        var result = 'Invest Systems';
        expect(subject).toEqual(result);
    });
});
//# sourceMappingURL=app.e2e-spec.js.map