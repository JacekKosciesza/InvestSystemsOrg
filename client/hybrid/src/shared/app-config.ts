export class AppConfig {
    culture: string
    theme: string;
    tutorial: boolean;    
};

export let DEFAULT_APP_CONFIG : AppConfig = {
    culture: 'en',
    theme: 'default',
    tutorial: true
}