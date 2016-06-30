import { Component, OnInit } from '@angular/core';
import { Title }     from '@angular/platform-browser';

@Component({
    moduleId: module.id,
    selector: 'rule-one-notes.component',
    templateUrl: 'rule-one-notes.component.html',
})
export class RuleOneNotes implements OnInit {
    constructor(private titleService: Title) {
    }

    ngOnInit() {
        this.setTitle('Notes | Rule #1');
    }

    public setTitle( newTitle: string) {
        this.titleService.setTitle( newTitle );
    }
}