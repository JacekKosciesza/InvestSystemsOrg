import { Component, OnInit } from '@angular/core';

import { TeamMember } from './team-member';

@Component({
    selector: 'team-tab',
    templateUrl: 'team.tab.html'
})
export class TeamTab implements OnInit {
    public members: Array<TeamMember>;

    constructor() { }

    ngOnInit() {
        this.members = [
            new TeamMember('Jacek Kościesza', 'Founder', 'https://media.licdn.com/mpr/mpr/shrinknp_200_200/AAEAAQAAAAAAAAbJAAAAJGM3MDMwMTA5LWUzYmQtNGFiYy1hOWJiLTI1MjBjNDE0OWFhNQ.jpg'),
            new TeamMember('Jacek Kościesza', 'Manager', 'https://static.goldenline.pl/user_photo/250/user_1571834_4133dd_huge.jpg'),
            new TeamMember('Jacek Kościesza', 'Analyst', 'https://static.goldenline.pl/user_photo/250/user_1571834_4133dd_huge.jpg'),
            new TeamMember('Jacek Kościesza', 'Designer', 'https://static.goldenline.pl/user_photo/250/user_1571834_4133dd_huge.jpg'),
            new TeamMember('Jacek Kościesza', 'Marketer', 'https://static.goldenline.pl/user_photo/250/user_1571834_4133dd_huge.jpg'),
            new TeamMember('Jacek Kościesza', 'Editor', 'https://static.goldenline.pl/user_photo/250/user_1571834_4133dd_huge.jpg'),
            new TeamMember('Jacek Kościesza', 'Developer', 'https://static.goldenline.pl/user_photo/250/user_1571834_4133dd_huge.jpg'),
            new TeamMember('Jacek Kościesza', 'Tester', 'https://static.goldenline.pl/user_photo/250/user_1571834_4133dd_huge.jpg'),
            new TeamMember('Jacek Kościesza', 'Support', 'https://static.goldenline.pl/user_photo/250/user_1571834_4133dd_huge.jpg')
        ]
    }
}