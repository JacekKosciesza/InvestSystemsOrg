import { InMemoryDbService } from 'angular-in-memory-web-api';

export class MarginData implements InMemoryDbService {
  createDb() {
    let margins = [
      { companySymbol: 'XXII', stickerPrice: 45, marginOfSafety: 22, currentPrice: 51 }
    ];
    return {margins};
  }
}
