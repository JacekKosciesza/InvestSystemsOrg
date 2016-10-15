import { Component, OnInit } from '@angular/core';

import { TranslateService } from 'ng2-translate/ng2-translate';

import { TeamMember } from './team-member';

@Component({
    selector: 'team-tab',
    templateUrl: 'team.tab.html'
})
export class TeamTab implements OnInit {
    public members: Array<TeamMember>;

    constructor(private translate: TranslateService) { }

    ngOnInit() {
        this.translate.get(['_about.OMA', '_about.Founder', '_about.Manager', '_about.Analyst', '_about.Designer', '_about.Marketer', '_about.Editor', '_about.Developer', '_about.Tester', '_about.Support']).subscribe((t: string[]) => {
            this.members = [
                new TeamMember('Jacek Kościesza', t['_about.OMA'], 'http://www.ronbrauner.com/i/copywriter-multiple-personality.jpg'),
                new TeamMember('Jacek Kościesza', t['_about.Founder'], 'https://media.licdn.com/mpr/mpr/shrinknp_200_200/AAEAAQAAAAAAAAbJAAAAJGM3MDMwMTA5LWUzYmQtNGFiYy1hOWJiLTI1MjBjNDE0OWFhNQ.jpg'),
                new TeamMember('Jacek Kościesza', t['_about.Manager'], 'https://static.goldenline.pl/user_photo/250/user_1571834_4133dd_huge.jpg'),
                new TeamMember('Jacek Kościesza', t['_about.Analyst'], 'https://static.goldenline.pl/user_photo/250/user_1571834_4133dd_huge.jpg'),
                new TeamMember('Jacek Kościesza', t['_about.Designer'], 'https://static.goldenline.pl/user_photo/250/user_1571834_4133dd_huge.jpg'),
                new TeamMember('Jacek Kościesza', t['_about.Marketer'], 'https://static.goldenline.pl/user_photo/250/user_1571834_4133dd_huge.jpg'),
                new TeamMember('Jacek Kościesza', t['_about.Editor'], 'https://static.goldenline.pl/user_photo/250/user_1571834_4133dd_huge.jpg'),
                new TeamMember('Jacek Kościesza', t['_about.Developer'], 'https://static.goldenline.pl/user_photo/250/user_1571834_4133dd_huge.jpg'),
                new TeamMember('Jacek Kościesza', t['_about.Tester'], 'https://static.goldenline.pl/user_photo/250/user_1571834_4133dd_huge.jpg'),
                new TeamMember('Jacek Kościesza', t['_about.Support'], 'https://static.goldenline.pl/user_photo/250/user_1571834_4133dd_huge.jpg')
            ]
        });

    }
}