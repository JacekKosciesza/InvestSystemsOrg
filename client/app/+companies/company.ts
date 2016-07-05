export interface Company {
    $key: string, // Firebase
    name: string;
    abbreviation: string;
    fullName: string;
    address: string;
    state: string;
    ceo: string;
    phone: string;
    fax: string;
    website: string;
    email: string;

    ipoYear: string;
    actionsCount: number; // TODO: rename: shares count?
    marketValue: number;

    //competitors: Company[];
}