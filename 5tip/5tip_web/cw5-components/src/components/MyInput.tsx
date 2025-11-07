
import { useEffect, useRef, type InputHTMLAttributes } from 'react';


type Props =  {
    autoFocus?: boolean;
    label?: string;
} & InputHTMLAttributes<HTMLInputElement>;

// Alternatywne podejścia:

// 1. Użycie ComponentPropsWithoutRef:
// type Props = {
//     autoFocus?: boolean;
//     label?: string;
// } & React.ComponentPropsWithoutRef<'input'>;

// 2. Użycie DetailedHTMLProps:
// type Props = {
//     autoFocus?: boolean;
//     label?: string;
// } & React.DetailedHTMLProps<React.InputHTMLAttributes<HTMLInputElement>, HTMLInputElement>;

// 3. Użycie ComponentProps:
// type Props = {
//     autoFocus?: boolean;
//     label?: string;
// } & React.ComponentProps<'input'>;

const MyInput = (props: Props) => {
    const { style, className, ...rest } = props;
    const inputRef = useRef<HTMLInputElement>(null);
    useEffect(() => {
        if (inputRef.current) {
            inputRef.current.focus();
        }
    }, []);
    return (
        <div>
            <input
                type="text"
                ref={inputRef}
                style={style}
                className={className}
                {...rest}
            />
        </div>
    );
}

export default MyInput  