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

    sameDayAs(day: DateTime) {
        const firstModel = this.getModel()
        const secondModel = day.getModel()

        return firstModel.getDate() === secondModel.getDate()
            && firstModel.getMonth() === secondModel.getMonth()
            && firstModel.getFullYear() === secondModel.getFullYear()
    }

    getMonthAsString() {
        return this.dateModel.toLocaleString('default', { month: 'long' })
    }

    getYearAsString() {
        return this.dateModel.getFullYear().toString()
    }

    getWeeksInSameMonth() {
        const newDateModel = this.clone().getModel()

        newDateModel.setDate(1)
        const beginningWeekOffset = (newDateModel.getDay() - 1) * -1
        newDateModel.setDate(beginningWeekOffset)

        let initialDay = DateTime.fromDate(newDateModel)

        const weekCount = this.getOngoingWeekCount()
        let weeks: DateTime[][] = []

        for (let i = 0; i < weekCount; i++) {
            let week: DateTime[] = []

            for (let j = 1; j < 8; j++) {
                week.push(initialDay.addDays(j))
            }

            weeks.push(week)
            initialDay = week[6]
        }

        return weeks
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


    addDays(amount: number) {
        const dateCopy = this.clone()

        const currentDay = this.dateModel.getDate()
        dateCopy.dateModel.setDate(currentDay + amount)

        return DateTime.fromDate(dateCopy.dateModel)
    }

    toString() {
        return this.dateModel.toDateString()
    }

    addMonths(amount: number) {
        const dateCopy = this.clone()

        const currentDay = this.dateModel.getMonth()
        dateCopy.dateModel.setMonth(currentDay + amount)

        return DateTime.fromDate(dateCopy.dateModel)
    }

    getModel() {
        return this.dateModel
    }
}
