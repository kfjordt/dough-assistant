import type { ICloneable } from "./ICloneable"

export class DateTime implements ICloneable {
    private constructor(private dateModel: Date) { }
    
    static fromNumbers(year: number, month: number, day: number) {
        return new DateTime(new Date(year, month, day))
    }

    static fromDate(date: Date) {
        return new DateTime(date)
    }

    static fromNow() {
        return new DateTime(new Date(Date.now()))
    }

    clone() {
        return DateTime.fromNumbers(
            this.dateModel.getFullYear(),
            this.dateModel.getMonth(),
            this.dateModel.getDate()
        )
    }

    getWeeksInSameMonth() {
        const newDateModel = this
            .clone()
            .getModel()

        newDateModel.setDate(1)
        const beginningWeekOffset = (newDateModel.getDay() - 2) * -1
        newDateModel.setDate(beginningWeekOffset)

        let initialDay = DateTime.fromDate(newDateModel)

        const weekCount = this.getOngoingWeekCount()
        let weeks: DateTime[][] = []

        for (let i = 0; i < weekCount; i++) {
            let week: DateTime[] = []
            for (let j = 0; j < 7; j++) {
                week.push(initialDay.addDays(j))
            }

            weeks.push(week)
            initialDay = week[6]
        }

        return weeks
    }

    addDays(amount: number) {
        const currentDay = this.dateModel.getDate()

        const dateCopy = this.clone()
        dateCopy.dateModel.setDate(amount + currentDay)

        return DateTime.fromDate(dateCopy.dateModel)
    }

    getModel() {
        return this.dateModel
    }

    getOngoingWeekCount() {
        const newDateModel = this
            .clone()
            .getModel()

        newDateModel.setDate(1)

        if (newDateModel.getDay() === 1 && newDateModel.getMonth() === 1) {
            return 4
        } else {
            return 5
        }
    }
}
