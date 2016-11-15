var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") return Reflect.decorate(decorators, target, key, desc);
    switch (arguments.length) {
        case 2: return decorators.reduceRight(function(o, d) { return (d && d(o)) || o; }, target);
        case 3: return decorators.reduceRight(function(o, d) { return (d && d(target, key)), void 0; }, void 0);
        case 4: return decorators.reduceRight(function(o, d) { return (d && d(target, key, o)) || o; }, desc);
    }
};
var core_1 = require('@angular/core');
var AppComponent = (function () {
    function AppComponent() {
        this.title = 'ASP.NET MVC 5 with Angular 2';
        this.skills = ['MVC 5', 'Angular 2', 'TypeScript', 'Visual Studio 2015'];
        this.myskills = this.skills[1];
    }
    AppComponent = __decorate([
        core_1.Component({
            selector: 'my-app',
            template: "\n    <h2>My favorite skill is: {{myskills}}</h2>\n    <p>Skill:</p>\n    <ul>\n      <li *ngFor=\"let skl of skills\">\n        {{ skl }}\n      </li>\n    </ul>\n  "
        })
    ], AppComponent);
    return AppComponent;
})();
exports.AppComponent = AppComponent;
