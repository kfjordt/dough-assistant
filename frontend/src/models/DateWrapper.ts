import type { ICloneable } from "./ICloneable"

export class DateWrapper implements ICloneable {
    private constructor(private dateModel: Date) { }

    static fromNumbers(year: number, month: number, day: number) {
        return new DateWrapper(new Date(year, month, day))
    }

    static fromDate(date: Date) {
        return new DateWrapper(date)
    }

    static fromToday() {
        return new DateWrapper(new Date(Date.now()))
    }

    clone() {
        return DateWrapper.fromNumbers(
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

        let initialDay = DateWrapper.fromDate(newDateModel)

        const weekCount = this.getOngoingWeekCount()
        let weeks: DateWrapper[][] = []

        for (let i = 0; i < weekCount; i++) {
            let week: DateWrapper[] = []
            for (let j = 0; j < 7; j++) {
                week.push(initialDay.incrementAndCopy(j))
            }

            weeks.push(week)
            initialDay = week[6]
        }

        return weeks
    }

    incrementAndCopy(amount: number) {
        const currentDay = this.dateModel.getDate()

        const dateCopy = this.clone()
        dateCopy.dateModel.setDate(amount + currentDay)

        return DateWrapper.fromDate(dateCopy.dateModel)
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
