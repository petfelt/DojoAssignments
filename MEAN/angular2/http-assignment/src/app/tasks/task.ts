export class Task {
    constructor(
        public id: any,
        public title: string,
        public content: string,
        public created_at: Date = new Date(),
        public updated_at: Date = new Date()
    ){}
}
